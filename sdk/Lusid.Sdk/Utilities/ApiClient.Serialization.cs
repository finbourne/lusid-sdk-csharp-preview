using System;
using Lusid.Sdk.Model;
using JsonSubTypes;

// ReSharper disable once CheckNamespace
namespace Lusid.Sdk.Model
{
    /// <summary>
    /// Ideally we would not have to do this. It is here solely as the types that are automatically generated in
    /// the LusidInstrument base class (of which this is a partial extension) do not have the correct string identifiers
    /// for the instrument converters. e.g. "FxForwardInstrument" not "FxForward". We have a choice to remove this by either
    /// improving the open-api generation or rename the DTO classes that we generate (breaking change). 
    /// </summary>
    [JsonSubtypes.KnownSubType(typeof(FxForwardInstrument), "FxForward")]
    [JsonSubtypes.KnownSubType(typeof(SwapInstrument), "InterestRateSwap")]
    [JsonSubtypes.KnownSubType(typeof(FloatingLeg), "FloatingRateLeg")]
    [JsonSubtypes.KnownSubType(typeof(FixedLeg), "FixedRateLeg")]
    [JsonSubtypes.KnownSubType(typeof(BondInstrument), "Bond")]
    [JsonSubtypes.KnownSubType(typeof(ExoticInstrument), "Exotic")]
    [JsonSubtypes.KnownSubType(typeof(Swaption), "InterestRateSwaption")]
    [JsonSubtypes.KnownSubType(typeof(CdsInstrument), "CreditDefaultSwap")]
    public partial class LusidInstrument : IEquatable<LusidInstrument>
    {

    }
}

// ReSharper disable once CheckNamespace
namespace Lusid.Sdk.Client
{
    /// <summary>
    /// api extension to enable modification of serialization. Can only use this if the JsonSubTypes annotations to LusidInstrument in both this file and
    /// the models one (those are auto-generated and hard to disable) are removed. 
    /// </summary>
    public partial class ApiClient : IDisposable
    {
        /// <summary>
        /// For deserialization of objects we need to ensure that the client has the required json converters.
        /// Open-Api currently does not do this for us as the default Jsonsubtype names do not match.
        /// This is one (currently unused) alternative whereby we could register the types into the client ApiFactory.
        /// The alternative (used) is the duplicate type registration extension for LusidInstrument above. 
        /// </summary>
        public void RegisterConverters()
        {
            serializerSettings.Converters.Add(JsonSubtypesConverterBuilder
                .Of(typeof(LusidInstrument), "InstrumentType")
                .RegisterSubtype(typeof(FxForwardInstrument), LusidInstrument.InstrumentTypeEnum.FxForward)
                .RegisterSubtype(typeof(FxOption), LusidInstrument.InstrumentTypeEnum.FxOption)
                .RegisterSubtype(typeof(SwapInstrument), LusidInstrument.InstrumentTypeEnum.InterestRateSwap)
                .RegisterSubtype(typeof(FixedLeg), LusidInstrument.InstrumentTypeEnum.FixedRateLeg)
                .RegisterSubtype(typeof(FloatingLeg), LusidInstrument.InstrumentTypeEnum.FloatingRateLeg)
                .RegisterSubtype(typeof(CdsInstrument), LusidInstrument.InstrumentTypeEnum.CreditDefaultSwap)
                .RegisterSubtype(typeof(BondInstrument), LusidInstrument.InstrumentTypeEnum.Bond)
                .RegisterSubtype(typeof(EquityOption), LusidInstrument.InstrumentTypeEnum.EquityOption)
                .RegisterSubtype(typeof(Swaption), LusidInstrument.InstrumentTypeEnum.InterestRateSwaption)
                .SerializeDiscriminatorProperty()
                .Build());
        }
    }
}
