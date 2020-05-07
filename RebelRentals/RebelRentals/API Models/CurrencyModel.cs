using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals
{
    public partial class CurrencyModel
    {
        [JsonProperty("results")]
        public Results Results { get; set; }
    }

    public partial class Results
    {
        [JsonProperty("ALL")]
        public Currency All { get; set; }

        [JsonProperty("XCD")]
        public Currency Xcd { get; set; }

        [JsonProperty("EUR")]
        public Currency Eur { get; set; }

        [JsonProperty("BBD")]
        public Currency Bbd { get; set; }

        [JsonProperty("BTN")]
        public Currency Btn { get; set; }

        [JsonProperty("BND")]
        public Currency Bnd { get; set; }

        [JsonProperty("XAF")]
        public Currency Xaf { get; set; }

        [JsonProperty("CUP")]
        public Currency Cup { get; set; }

        [JsonProperty("USD")]
        public Currency Usd { get; set; }

        [JsonProperty("FKP")]
        public Currency Fkp { get; set; }

        [JsonProperty("GIP")]
        public Currency Gip { get; set; }

        [JsonProperty("HUF")]
        public Currency Huf { get; set; }

        [JsonProperty("IRR")]
        public Currency Irr { get; set; }

        [JsonProperty("JMD")]
        public Currency Jmd { get; set; }

        [JsonProperty("AUD")]
        public Currency Aud { get; set; }

        [JsonProperty("LAK")]
        public Currency Lak { get; set; }

        [JsonProperty("LYD")]
        public Currency Lyd { get; set; }

        [JsonProperty("MKD")]
        public Currency Mkd { get; set; }

        [JsonProperty("XOF")]
        public Currency Xof { get; set; }

        [JsonProperty("NZD")]
        public Currency Nzd { get; set; }

        [JsonProperty("OMR")]
        public Currency Omr { get; set; }

        [JsonProperty("PGK")]
        public Currency Pgk { get; set; }

        [JsonProperty("RWF")]
        public Currency Rwf { get; set; }

        [JsonProperty("WST")]
        public Currency Wst { get; set; }

        [JsonProperty("RSD")]
        public Currency Rsd { get; set; }

        [JsonProperty("SEK")]
        public Currency Sek { get; set; }

        [JsonProperty("TZS")]
        public Currency Tzs { get; set; }

        [JsonProperty("AMD")]
        public Currency Amd { get; set; }

        [JsonProperty("BSD")]
        public Currency Bsd { get; set; }

        [JsonProperty("BAM")]
        public Currency Bam { get; set; }

        [JsonProperty("CVE")]
        public Currency Cve { get; set; }

        [JsonProperty("CNY")]
        public Currency Cny { get; set; }

        [JsonProperty("CRC")]
        public Currency Crc { get; set; }

        [JsonProperty("CZK")]
        public Currency Czk { get; set; }

        [JsonProperty("ERN")]
        public Currency Ern { get; set; }

        [JsonProperty("GEL")]
        public Currency Gel { get; set; }

        [JsonProperty("HTG")]
        public Currency Htg { get; set; }

        [JsonProperty("INR")]
        public Currency Inr { get; set; }

        [JsonProperty("JOD")]
        public Currency Jod { get; set; }

        [JsonProperty("KRW")]
        public Currency Krw { get; set; }

        [JsonProperty("LBP")]
        public Currency Lbp { get; set; }

        [JsonProperty("MWK")]
        public Currency Mwk { get; set; }

        [JsonProperty("MRO")]
        public Currency Mro { get; set; }

        [JsonProperty("MZN")]
        public Currency Mzn { get; set; }

        [JsonProperty("ANG")]
        public Currency Ang { get; set; }

        [JsonProperty("PEN")]
        public Currency Pen { get; set; }

        [JsonProperty("QAR")]
        public Currency Qar { get; set; }

        [JsonProperty("STD")]
        public Currency Std { get; set; }

        [JsonProperty("SLL")]
        public Currency Sll { get; set; }

        [JsonProperty("SOS")]
        public Currency Sos { get; set; }

        [JsonProperty("SDG")]
        public Currency Sdg { get; set; }

        [JsonProperty("SYP")]
        public Currency Syp { get; set; }

        [JsonProperty("AOA")]
        public Currency Aoa { get; set; }

        [JsonProperty("AWG")]
        public Currency Awg { get; set; }

        [JsonProperty("BHD")]
        public Currency Bhd { get; set; }

        [JsonProperty("BZD")]
        public Currency Bzd { get; set; }

        [JsonProperty("BWP")]
        public Currency Bwp { get; set; }

        [JsonProperty("BIF")]
        public Currency Bif { get; set; }

        [JsonProperty("KYD")]
        public Currency Kyd { get; set; }

        [JsonProperty("COP")]
        public Currency Cop { get; set; }

        [JsonProperty("DKK")]
        public Currency Dkk { get; set; }

        [JsonProperty("GTQ")]
        public Currency Gtq { get; set; }

        [JsonProperty("HNL")]
        public Currency Hnl { get; set; }

        [JsonProperty("IDR")]
        public Currency Idr { get; set; }

        [JsonProperty("ILS")]
        public Currency Ils { get; set; }

        [JsonProperty("KZT")]
        public Currency Kzt { get; set; }

        [JsonProperty("KWD")]
        public Currency Kwd { get; set; }

        [JsonProperty("LSL")]
        public Currency Lsl { get; set; }

        [JsonProperty("MYR")]
        public Currency Myr { get; set; }

        [JsonProperty("MUR")]
        public Currency Mur { get; set; }

        [JsonProperty("MNT")]
        public Currency Mnt { get; set; }

        [JsonProperty("MMK")]
        public Currency Mmk { get; set; }

        [JsonProperty("NGN")]
        public Currency Ngn { get; set; }

        [JsonProperty("PAB")]
        public Currency Pab { get; set; }

        [JsonProperty("PHP")]
        public Currency Php { get; set; }

        [JsonProperty("RON")]
        public Currency Ron { get; set; }

        [JsonProperty("SAR")]
        public Currency Sar { get; set; }

        [JsonProperty("SGD")]
        public Currency Sgd { get; set; }

        [JsonProperty("ZAR")]
        public Currency Zar { get; set; }

        [JsonProperty("SRD")]
        public Currency Srd { get; set; }

        [JsonProperty("TWD")]
        public Currency Twd { get; set; }

        [JsonProperty("TOP")]
        public Currency Top { get; set; }

        [JsonProperty("VEF")]
        public Currency Vef { get; set; }

        [JsonProperty("DZD")]
        public Currency Dzd { get; set; }

        [JsonProperty("ARS")]
        public Currency Ars { get; set; }

        [JsonProperty("AZN")]
        public Currency Azn { get; set; }

        [JsonProperty("BYR")]
        public Currency Byr { get; set; }

        [JsonProperty("BOB")]
        public Currency Bob { get; set; }

        [JsonProperty("BGN")]
        public Currency Bgn { get; set; }

        [JsonProperty("CAD")]
        public Currency Cad { get; set; }

        [JsonProperty("CLP")]
        public Currency Clp { get; set; }

        [JsonProperty("CDF")]
        public Currency Cdf { get; set; }

        [JsonProperty("DOP")]
        public Currency Dop { get; set; }

        [JsonProperty("FJD")]
        public Currency Fjd { get; set; }

        [JsonProperty("GMD")]
        public Currency Gmd { get; set; }

        [JsonProperty("GYD")]
        public Currency Gyd { get; set; }

        [JsonProperty("ISK")]
        public Currency Isk { get; set; }

        [JsonProperty("IQD")]
        public Currency Iqd { get; set; }

        [JsonProperty("JPY")]
        public Currency Jpy { get; set; }

        [JsonProperty("KPW")]
        public Currency Kpw { get; set; }

        [JsonProperty("LVL")]
        public Currency Lvl { get; set; }

        [JsonProperty("CHF")]
        public Currency Chf { get; set; }

        [JsonProperty("MGA")]
        public Currency Mga { get; set; }

        [JsonProperty("MDL")]
        public Currency Mdl { get; set; }

        [JsonProperty("MAD")]
        public Currency Mad { get; set; }

        [JsonProperty("NPR")]
        public Currency Npr { get; set; }

        [JsonProperty("NIO")]
        public Currency Nio { get; set; }

        [JsonProperty("PKR")]
        public Currency Pkr { get; set; }

        [JsonProperty("PYG")]
        public Currency Pyg { get; set; }

        [JsonProperty("SHP")]
        public Currency Shp { get; set; }

        [JsonProperty("SCR")]
        public Currency Scr { get; set; }

        [JsonProperty("SBD")]
        public Currency Sbd { get; set; }

        [JsonProperty("LKR")]
        public Currency Lkr { get; set; }

        [JsonProperty("THB")]
        public Currency Thb { get; set; }

        [JsonProperty("TRY")]
        public Currency Try { get; set; }

        [JsonProperty("AED")]
        public Currency Aed { get; set; }

        [JsonProperty("VUV")]
        public Currency Vuv { get; set; }

        [JsonProperty("YER")]
        public Currency Yer { get; set; }

        [JsonProperty("AFN")]
        public Currency Afn { get; set; }

        [JsonProperty("BDT")]
        public Currency Bdt { get; set; }

        [JsonProperty("BRL")]
        public Currency Brl { get; set; }

        [JsonProperty("KHR")]
        public Currency Khr { get; set; }

        [JsonProperty("KMF")]
        public Currency Kmf { get; set; }

        [JsonProperty("HRK")]
        public Currency Hrk { get; set; }

        [JsonProperty("DJF")]
        public Currency Djf { get; set; }

        [JsonProperty("EGP")]
        public Currency Egp { get; set; }

        [JsonProperty("ETB")]
        public Currency Etb { get; set; }

        [JsonProperty("XPF")]
        public Currency Xpf { get; set; }

        [JsonProperty("GHS")]
        public Currency Ghs { get; set; }

        [JsonProperty("GNF")]
        public Currency Gnf { get; set; }

        [JsonProperty("HKD")]
        public Currency Hkd { get; set; }

        [JsonProperty("XDR")]
        public Currency Xdr { get; set; }

        [JsonProperty("KES")]
        public Currency Kes { get; set; }

        [JsonProperty("KGS")]
        public Currency Kgs { get; set; }

        [JsonProperty("LRD")]
        public Currency Lrd { get; set; }

        [JsonProperty("MOP")]
        public Currency Mop { get; set; }

        [JsonProperty("MVR")]
        public Currency Mvr { get; set; }

        [JsonProperty("MXN")]
        public Currency Mxn { get; set; }

        [JsonProperty("NAD")]
        public Currency Nad { get; set; }

        [JsonProperty("NOK")]
        public Currency Nok { get; set; }

        [JsonProperty("PLN")]
        public Currency Pln { get; set; }

        [JsonProperty("RUB")]
        public Currency Rub { get; set; }

        [JsonProperty("SZL")]
        public Currency Szl { get; set; }

        [JsonProperty("TJS")]
        public Currency Tjs { get; set; }

        [JsonProperty("TTD")]
        public Currency Ttd { get; set; }

        [JsonProperty("UGX")]
        public Currency Ugx { get; set; }

        [JsonProperty("UYU")]
        public Currency Uyu { get; set; }

        [JsonProperty("VND")]
        public Currency Vnd { get; set; }

        [JsonProperty("TND")]
        public Currency Tnd { get; set; }

        [JsonProperty("UAH")]
        public Currency Uah { get; set; }

        [JsonProperty("UZS")]
        public Currency Uzs { get; set; }

        [JsonProperty("TMT")]
        public Currency Tmt { get; set; }

        [JsonProperty("GBP")]
        public Currency Gbp { get; set; }

        [JsonProperty("ZMW")]
        public Currency Zmw { get; set; }

        [JsonProperty("BTC")]
        public Currency Btc { get; set; }

        [JsonProperty("BYN")]
        public Currency Byn { get; set; }

        [JsonProperty("BMD")]
        public Currency Bmd { get; set; }

        [JsonProperty("GGP")]
        public Currency Ggp { get; set; }

        [JsonProperty("CLF")]
        public Currency Clf { get; set; }

        [JsonProperty("CUC")]
        public Currency Cuc { get; set; }

        [JsonProperty("IMP")]
        public Currency Imp { get; set; }

        [JsonProperty("JEP")]
        public Currency Jep { get; set; }

        [JsonProperty("SVC")]
        public Currency Svc { get; set; }

        [JsonProperty("ZMK")]
        public Currency Zmk { get; set; }

        [JsonProperty("XAG")]
        public Currency Xag { get; set; }

        [JsonProperty("ZWL")]
        public Currency Zwl { get; set; }
    }

    public partial class Currency
    {
        [JsonProperty("currencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
