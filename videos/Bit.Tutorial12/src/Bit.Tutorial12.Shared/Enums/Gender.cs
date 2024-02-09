﻿namespace Bit.Tutorial12.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<Gender>))]
public enum Gender
{
    Male,
    Female,
    Other
}
