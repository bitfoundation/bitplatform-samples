﻿namespace Bit.Tutorial07.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<Gender>))]
public enum Gender
{
    Male,
    Female,
    Other
}
