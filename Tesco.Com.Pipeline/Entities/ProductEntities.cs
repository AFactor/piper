using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Tesco.Com.Pipeline.Utilities;

namespace Tesco.Com.Pipeline.Entities.ProductEntities
{

    public class Identifiers
    {
        public string BaseProductId { get; set; }
    }

    public class Status
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Type
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class ShelfLife
    {
        public string IsLimited { get; set; }
        public string Expiry { get; set; }
    }

    public class Summary
    {
        public string BaseProductId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string DateOfmanufacture { get; set; }
        public List<Status> Status { get; set; }
        public List<Type> Type { get; set; }
        public List<ShelfLife> ShelfLife { get; set; }
    }

    public class Medium
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class CustomAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Result
    {
        public string ProductId { get; set; }
        public Identifiers Identifiers { get; set; }
        public Summary Summary { get; set; }
        public List<Medium> Media { get; set; }
        public List<CustomAttribute> CustomAttributes { get; set; }
        public LinePrice Price { get; set; }
        public PromotionObject Promotion { get; set; }
    }

    public class ResultETL
    {
        public string ProductId { get; set; }
        public string BaseProductId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string DateOfmanufacture { get; set; }
        public List<Medium> Media { get; set; }
        public List<CustomAttribute> CustomAttributes { get; set; }
        public string Uom { get; set; }
        public double Quantity { get; set; }
        public double UnitSellingPrice { get; set; }
        public double TotalSellingPrice { get; set; }
        public string PromoId { get; set; }
        public string PromoDescription { get; set; }
        public string PromoStartDate { get; set; }
        public string PromoEndDate { get; set; }
        public string RewardType { get; set; }
        public bool ActivationBarcodeRequired { get; set; }
        public double PromoThreshold { get; set; }
        public int StepCount { get; set; }
        public string PromoType { get; set; }
        public string IconType { get; set; }
    }

    public class ProductResultETL
    {
        public List<ResultETL> Results { get; set; }
        public int TotalMatchedCount { get; set; }
    }

    public class ProductResult
    {
        public List<Result> Results { get; set; }
        public int TotalMatchedCount { get; set; }
    }

    public class UnitSellingPrice
    {
        public double Amount { get; set; }
    }

    public class TotalSellingPrice
    {
        public double Amount { get; set; }
    }

    public class LinePrice
    {
        public string ProductId { get; set; }
        public string Uom { get; set; }
        public double Quantity { get; set; }
        public UnitSellingPrice UnitSellingPrice { get; set; }
        public TotalSellingPrice TotalSellingPrice { get; set; }
    }


    public class PriceResultSummary
    {
        public List<PriceResult> Prices { get; set; }
    }

    public class PriceResult
    {
        public string ValidFrom { get; set; }
        public string ValidTill { get; set; }
        public string Pricetype { get; set; }
        public List<LinePrice> LinePrices { get; set; }
    }


    public class Attachment
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class Bucket
    {
        public string Id { get; set; }
        public List<Attachment> Attachments { get; set; }
    }

    public class PromotionObject
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string RewardType { get; set; }
        public bool ActivationBarcodeRequired { get; set; }
        public double Threshold { get; set; }
        public int StepCount { get; set; }
        public List<Bucket> Buckets { get; set; }
        public string ProductId { get; set; }
    }


}