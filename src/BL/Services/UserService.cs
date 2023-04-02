using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;

namespace BL.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public UserService(IUserRepository userRepository, ITournamentRepository tournamentRepository)
        {
            _userRepository = userRepository;
            _tournamentRepository = tournamentRepository;
        }

        public User register(string login, string password)
        {
            User user = _userRepository.getByLogin(login);
            if (user == null)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(password);
                user = new User(login, hash);
                _userRepository.create(user);
            }
            else
            {
                throw new Exception("Пользователь с таким логином уже существует.");
            }

            return user;
        }

        public User logIn(string login, string password)
        {
            User user = _userRepository.getByLogin(login);
            if (user != null)
            {
                if (!user.verify(password))
                {
                    throw new Exception("Неверный пароль.");
                }
            }
            else
            {
                throw new Exception("Не существует пользователя с таким логином.");
            }

            return user;
        }

        public void changeUserPermissions(int userId)
        {
            User user = _userRepository.getById(userId);
            if (user != null)
            {
                User newUser = new User(user.Login, user.PasswordHash, permission: "admin", id: user.Id);
                _userRepository.update(newUser);
            }
            else
            {
                throw new Exception("Не существует пользователя с таким id.");
            }
        }

        public User getUser(int userId)
        {
            User user = _userRepository.getById(userId);
            if (user == null)
            {
                throw new Exception("Не существует пользователя с таким id.");
            }

            return user;
        }

        public IEnumerable<User> getAllUsers()
        {
            return _userRepository.getAll();
        }

        public IEnumerable<Tournament> getUserTournaments(int userId)
        { 
            return _tournamentRepository.getByUser(userId);
        }
    }
}
