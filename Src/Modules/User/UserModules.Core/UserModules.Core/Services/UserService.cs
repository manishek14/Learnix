using AutoMapper;
using Common.Application;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserModules.Core.DTOs;
using UserModules.Core.Repositories;
using UserModules.Core.Utilities;

namespace UserModules.Core.Services
{
    public interface IUserService
    {
        Task<OperationResult> Register(RegisterUserCommand command);
        Task<OperationResult<UserDto>> Login(LoginUserCommand command);
        Task<UserDto> GetUserById(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Register(RegisterUserCommand command)
        {
            if (await _repository.ExistsAsync(u => u.PhoneNumber == command.PhoneNumber || u.Email == command.Email))
                return OperationResult.Error("کاربری با این شماره موبایل یا ایمیل قبلا ثبت‌نام کرده است.");

            var user = _mapper.Map<UserModules.Data.Entities.User>(command);
            user.Id = Guid.NewGuid();
            user.CreationDate = DateTime.Now;
            user.IsActive = true;
            user.Password = PasswordHasher.Hash(command.Password);

            await _repository.AddAsync(user);
            await _repository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult<UserDto>> Login(LoginUserCommand command)
        {
            var hashedPassword = PasswordHasher.Hash(command.Password);

            var userList = await _repository.GetListAsync(u => u.PhoneNumber == command.PhoneNumber && u.Password == hashedPassword);
            var foundUser = userList.FirstOrDefault();

            if (foundUser == null)
                return OperationResult<UserDto>.Error("شماره موبایل یا رمز عبور اشتباه است.");

            if (!foundUser.IsActive)
                return OperationResult<UserDto>.Error("حساب کاربری شما غیرفعال شده است.");

            var result = _mapper.Map<UserDto>(foundUser);
            return OperationResult<UserDto>.Success(result);
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _repository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }
    }

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserCommand, UserModules.Data.Entities.User>();
            CreateMap<UserModules.Data.Entities.User, UserDto>();
        }
    }
}