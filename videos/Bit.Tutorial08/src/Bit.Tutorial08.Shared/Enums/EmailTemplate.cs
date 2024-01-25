namespace Bit.Tutorial08.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<EmailTemplate>))]
public enum EmailTemplate
{
    EmailChange,
    EmailConfirmation
}
