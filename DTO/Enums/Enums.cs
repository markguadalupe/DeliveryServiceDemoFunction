using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Model.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemUnit : int
    {
        Kg,
        Pc
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemStatus : int
    {
        Good,
        Damaged
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeliveryStatus : int
    {
        PickupRequested,
        PickupConfirmed,
        InTransit,
        DropoffRequested,
        DropoffConfirmed
    }
}
