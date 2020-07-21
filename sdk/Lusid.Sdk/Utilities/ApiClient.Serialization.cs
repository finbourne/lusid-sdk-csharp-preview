using System;
using Lusid.Sdk.Model;
using JsonSubTypes;

// ReSharper disable once CheckNamespace
namespace Lusid.Sdk.Client
{
    public partial class ApiClient : IDisposable
    {
        /// <summary>
        /// for deserialization of objects we need to ensure the client has the required json covnerters.
        /// Open-Api currently does not do this for us.
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