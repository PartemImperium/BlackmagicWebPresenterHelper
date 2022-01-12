using System.ComponentModel;

[Description("UI SETTINGS")]
public class UiSettingsBlock
{
    [Description("Available Locales")]
    public string? AvailableLocales { get; set; }//TODO: Make this a List<string> (or List<Locale>) (its actual value is a CSV of locales)

    [Description("Current Locale")]
    public string? DefaultInterface { get; set; }//TODO: Make this a Locale

    [Description("Available Audio Meters")]
    public string? AvailableAudioMeters { get; set; }//TODO: Make this a List<string> (or List<AudioMeterTypes> this will be more work to maintain though if new ones are added) (its actual value is a CSV of audo meter types)

    [Description("Current Audio Meter")]
    public string? CurrentAudioMeters { get; set; }//TODO: Make this a whatever T Type AvailableAudioMeters uses
}