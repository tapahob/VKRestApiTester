using System;
using System.Collections.Generic;
using NUnit.Framework;
using VKRestApiTester.REST.Methods;
using VKRestApiTester.REST.Models;

namespace VKRestApiTester.Tests
{    
    [TestFixture]
    class AuthSignupTests
    {
        [Test]
        public void PositiveAuthSignupTest()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"first_name", "Иван"},
                {"last_name", "Иванов"},
                // При многократном повторе одного и тогоже номера телефона вылетает капча
                {"phone", "+795148" + new Random().Next(10000, 99999)},
                {"password", "123123Aa"},
                {"test_mode", 1},
                {"sex", 2},
            };
            var result = new AuthSignup().Execute<AuthSignupModel>(parameters);
            Assert.False(String.IsNullOrWhiteSpace(result.sid), $"Вернулся пустой SID!\n{result.ErrorMSG}");
        }

        [Test]
        public void NegativeAuthSignupTest()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"first_name", "Иван"},
                {"last_name", "Иванов"},
                {"phone", string.Empty},
                {"password", "123123Aa"},
                {"test_mode", 1},
                {"sex", 2},
            };
            var result = new AuthSignup().Execute<AuthSignupModel>(parameters);
            Assert.AreEqual(result.ErrorCode, "100", "Вернулся ErrorCode отличный от 100!");
            Assert.AreEqual(result.ErrorMSG, "One of the parameters specified was missing or invalid: phone is undefined", "Некорректный ErrorMSG!");
        }
    }
}
