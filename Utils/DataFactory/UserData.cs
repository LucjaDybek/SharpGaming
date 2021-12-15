using System;
using Bogus;
using IFlow.Testing.Utils.DataBase;
using Bogus.Extensions.UnitedKingdom;

namespace IFlow.Testing.Utils.DataFactory
{
    public static class UserData
    {
        public static readonly User CorrectApiUser = new User(UserConsts.key, UserConsts.header);

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public static Faker<User> CreateUserData()
        {
           return  new Faker<User>()
                              .CustomInstantiator(f => new User())
                              .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                              .RuleFor(u => u.LastName, f => f.Name.LastName())
                              .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                              .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                              .RuleFor(u => u.Country, f => f.Address.Country())
                              .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                              .RuleFor(u=>u.Address, f=>f.Address.StreetName())
                              .RuleFor(u => u.Password, f => f.Internet.Password(9, false, "", "6b"));
        }
    }
}
