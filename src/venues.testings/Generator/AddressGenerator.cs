﻿using PingDong.Testings;

namespace PingDong.Newmoon.Venues.Tests.Generators
{
    internal class AddressGenerator : ModelGenerator
    {
        public static Address Create()
        {
            return new Address
            {
                No = NextInt(1, 200).ToString(),
                Street = "Mokoia Road",
                City = "Auckland",
                ZipCode = "0626",
                Country = "New Zealand"
            };
        }
    }
}
