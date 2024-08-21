namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Purchases allow you to view and process purchases which have already been made. 
/// </summary>
public class ApiPurchase : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the contact associated with the purchase.
    /// </summary>
    public ApiProperty<int> ContactIdField => _contactIdField ??= new ApiProperty<int>(this, ContactIdKey);
    private ApiProperty<int>? _contactIdField;
    public const string ContactIdKey = "contact_id";
    /// <summary>
    /// Gets or sets the ID of the contact associated with the purchase.
    /// </summary>
    public int? ContactId { get => ContactIdField.Value; set => ContactIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the affiliate that referred the contact associated with the purchase.
    /// </summary>
    public ApiProperty<int> AffiliateIdField => _affiliateIdField ??= new ApiProperty<int>(this, AffiliateIdKey);
    private ApiProperty<int>? _affiliateIdField;
    public const string AffiliateIdKey = "affiliate_id";
    /// <summary>
    /// Gets or sets the ID of the affiliate that referred the contact associated with the purchase.
    /// </summary>
    public int? AffiliateId { get => AffiliateIdField.Value; set => AffiliateIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the purchased product.
    /// </summary>
    public ApiProperty<int> ProductIdField => _productIdField ??= new ApiProperty<int>(this, ProductIdKey);
    private ApiProperty<int>? _productIdField;
    public const string ProductIdKey = "product_id";
    /// <summary>
    /// Gets or sets the ID of the purchased product.
    /// </summary>
    public int? ProductId { get => ProductIdField.Value; set => ProductIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the user who controls the contact associated with the purchase.
    /// </summary>
    public ApiProperty<int> OwnerField => _ownerField ??= new ApiProperty<int>(this, OwnerKey);
    private ApiProperty<int>? _ownerField;
    public const string OwnerKey = "owner";
    /// <summary>
    /// Gets or sets the ID of the user who controls the contact associated with the purchase.
    /// </summary>
    public int? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the package the purchase belongs to. Default 0 if the purchase is not part of a package.
    /// </summary>
    public ApiProperty<int> PackageIdField => _packageIdField ??= new ApiProperty<int>(this, PackageIdKey);
    private ApiProperty<int>? _packageIdField;
    public const string PackageIdKey = "package_id";
    /// <summary>
    /// Gets or sets the ID of the package the purchase belongs to. Default 0 if the purchase is not part of a package.
    /// </summary>
    public int? PackageId { get => PackageIdField.Value; set => PackageIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the invoice the purchase belongs to. An invoice can contain multiple purchases.
    /// </summary>
    public ApiProperty<int> InvoiceIdField => _invoiceIdField ??= new ApiProperty<int>(this, InvoiceIdKey);
    private ApiProperty<int>? _invoiceIdField;
    public const string InvoiceIdKey = "invoice_id";
    /// <summary>
    /// Gets or sets the ID of the invoice the purchase belongs to. An invoice can contain multiple purchases.
    /// </summary>
    public int? InvoiceId { get => InvoiceIdField.Value; set => InvoiceIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the subscription the purchase belongs to. Default 0 if the product is not part of a subscription.
    /// </summary>
    public ApiProperty<int> SubscriptionIdField => _subscriptionIdField ??= new ApiProperty<int>(this, SubscriptionIdKey);
    private ApiProperty<int>? _subscriptionIdField;
    public const string SubscriptionIdKey = "subscription_id";
    /// <summary>
    /// Gets or sets the ID of the subscription the purchase belongs to. Default 0 if the product is not part of a subscription.
    /// </summary>
    public int? SubscriptionId { get => SubscriptionIdField.Value; set => SubscriptionIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the order the purchase belongs to. Default 0 if the product does not have an order associated with it.
    /// </summary>
    public ApiProperty<int> OrderIdField => _orderIdField ??= new ApiProperty<int>(this, OrderIdKey);
    private ApiProperty<int>? _orderIdField;
    public const string OrderIdKey = "order_id";
    /// <summary>
    /// Gets or sets the ID of the order the purchase belongs to. Default 0 if the product does not have an order associated with it.
    /// </summary>
    public int? OrderId { get => OrderIdField.Value; set => OrderIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the affiliate to be credited for the purchase.
    /// </summary>
    public ApiProperty<int> OprIdField => _oprIdField ??= new ApiProperty<int>(this, OprIdKey);
    private ApiProperty<int>? _oprIdField;
    public const string OprIdKey = "oprid";
    /// <summary>
    /// Gets or sets the ID of the affiliate to be credited for the purchase.
    /// </summary>
    public int? OprId { get => OprIdField.Value; set => OprIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the purchased product's code for integrations.
    /// </summary>
    public ApiPropertyString SkuField => _skuField ??= new ApiPropertyString(this, SkuKey);
    private ApiPropertyString? _skuField;
    public const string SkuKey = "sku";
    /// <summary>
    /// Gets or sets the purchased product's code for integrations.
    /// </summary>
    public string? Sku { get => SkuField.Value; set => SkuField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the description of the product purchased.
    /// </summary>
    public ApiPropertyString DescriptionField => _descriptionField ??= new ApiPropertyString(this, DescriptionKey);
    private ApiPropertyString? _descriptionField;
    public const string DescriptionKey = "description";
    /// <summary>
    /// Gets or sets the description of the product purchased.
    /// </summary>
    public string? Description { get => DescriptionField.Value; set => DescriptionField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the date the purchase was made.
    /// </summary>
    public ApiPropertyDateTime DateAddedField => _dateAddedField ??= new ApiPropertyDateTime(this, DateAddedKey);
    private ApiPropertyDateTime? _dateAddedField;
    public const string DateAddedKey = "date";
    /// <summary>
    /// Gets or sets the date the purchase was made.
    /// </summary>
    public DateTimeOffset? DateAdded { get => DateAddedField.Value; set => DateAddedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the purchase was last modified, such as a change in status.
    /// </summary>
    public ApiPropertyDateTime DateLastModifiedField => _dateLastModifiedField ??= new ApiPropertyDateTime(this, DateLastModifiedKey);
    private ApiPropertyDateTime? _dateLastModifiedField;
    public const string DateLastModifiedKey = "dlm";
    /// <summary>
    /// Gets or sets the date the purchase was last modified, such as a change in status.
    /// </summary>
    public DateTimeOffset? DateLastModified { get => DateLastModifiedField.Value; set => DateLastModifiedField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the price of the product purchased.
    /// </summary>
    public ApiProperty<decimal> PriceField => _priceField ??= new ApiProperty<decimal>(this, PriceKey);
    private ApiProperty<decimal>? _priceField;
    public const string PriceKey = "price";
    /// <summary>
    /// Gets or sets the price of the product purchased.
    /// </summary>
    public decimal? Price { get => PriceField.Value; set => PriceField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the name of the product purchased.
    /// </summary>
    public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
    private ApiPropertyString? _nameField;
    public const string NameKey = "name";
    /// <summary>
    /// Gets or sets the name of the product purchased.
    /// </summary>
    public string? Name { get => NameField.Value; set => NameField.Value = value; }
   
    /// <summary>
    /// Returns a ApiProperty object to get or set the quantity of the product purchased.
    /// </summary>
    public ApiProperty<int> QuantityField => _quantityField ??= new ApiProperty<int>(this, QuantityKey);
    private ApiProperty<int>? _quantityField;
    public const string QuantityKey = "quantity";
    /// <summary>
    /// Gets or sets the quantity of the product purchased.
    /// </summary>
    public int? Quantity { get => QuantityField.Value; set => QuantityField.Value = value; }
       
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the coupon applied to the purchase.
    /// </summary>
    public ApiProperty<int> CouponIdField => _couponIdField ??= new ApiProperty<int>(this, CouponIdKey);
    private ApiProperty<int>? _couponIdField;
    public const string CouponIdKey = "coupon_id";
    /// <summary>
    /// Gets or sets the ID of the coupon applied to the purchase.
    /// </summary>
    public int? CouponId { get => CouponIdField.Value; set => CouponIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the coupon code corresponding to the coupon used, if a coupon was applied to the purchase.
    /// </summary>
    public ApiProperty<int> CouponCodeIdField => _couponCodeIdField ??= new ApiProperty<int>(this, CouponCodeIdKey);
    private ApiProperty<int>? _couponCodeIdField;
    public const string CouponCodeIdKey = "coupon_code_id";
    /// <summary>
    /// Gets or sets the ID of the coupon code corresponding to the coupon used, if a coupon was applied to the purchase.
    /// </summary>
    public int? CouponCodeId { get => CouponCodeIdField.Value; set => CouponCodeIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the amount discounted from the purchase.
    /// </summary>
    public ApiProperty<decimal> DiscountField => _discountField ??= new ApiProperty<decimal>(this, DiscountKey);
    private ApiProperty<decimal>? _discountField;
    public const string DiscountKey = "discount";
    /// <summary>
    /// Gets or sets the amount discounted from the purchase.
    /// </summary>
    public decimal? Discount { get => DiscountField.Value; set => DiscountField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the type of purchase. 
    /// </summary>
    public ApiPropertyIntEnum<TransactionType> TypeField => _typeField ??= new ApiPropertyIntEnum<TransactionType>(this, TypeKey);
    private ApiPropertyIntEnum<TransactionType>? _typeField;
    public const string TypeKey = "type";
    /// <summary>
    /// Gets or sets the type of purchase. 
    /// </summary>
    public TransactionType? Type { get => TypeField.Value; set => TypeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the status of the purchase.
    /// </summary>
    public ApiPropertyIntEnum<TransactionStatus> StatusField => _statusField ??= new ApiPropertyIntEnum<TransactionStatus>(this, StatusKey);
    private ApiPropertyIntEnum<TransactionStatus>? _statusField;
    public const string StatusKey = "status";
    /// <summary>
    /// Gets or sets the status of the purchase.
    /// </summary>
    public TransactionStatus? Status { get => StatusField.Value; set => StatusField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the commission earned by the referrer directly associated with the purchase.
    /// </summary>
    public ApiProperty<decimal> Level1Field => _level1Field ??= new ApiProperty<decimal>(this, Level1Key);
    private ApiProperty<decimal>? _level1Field;
    public const string Level1Key = "level1";
    /// <summary>
    /// Gets or sets the commission earned by the referrer directly associated with the purchase.
    /// </summary>
    public decimal? Level1 { get => Level1Field.Value; set => Level1Field.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the commission earned by the original referrer associated with the purchase in a two-tier partner program.
    /// </summary>
    public ApiProperty<decimal> Level2Field => _level2Field ??= new ApiProperty<decimal>(this, Level2Key);
    private ApiProperty<decimal>? _level2Field;
    public const string Level2Key = "level2";
    /// <summary>
    /// Gets or sets the commission earned by the original referrer associated with the purchase in a two-tier partner program.
    /// </summary>
    public decimal? Level2 { get => Level2Field.Value; set => Level2Field.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the total price of the purchase, calculated with the discount subtracted from the quantity purchased.
    /// </summary>
    public ApiProperty<decimal> TotalPriceField => _totalPriceField ??= new ApiProperty<decimal>(this, TotalPriceKey);
    private ApiProperty<decimal>? _totalPriceField;
    public const string TotalPriceKey = "total_price";
    /// <summary>
    /// Gets or sets the total price of the purchase, calculated with the discount subtracted from the quantity purchased.
    /// </summary>
    public decimal? TotalPrice { get => TotalPriceField.Value; set => TotalPriceField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the name of the affiliate that referred the contact associated with the purchase.
    /// </summary>
    public ApiPropertyString AffiliateField => _affiliateField ??= new ApiPropertyString(this, AffiliateKey);
    private ApiPropertyString? _affiliateField;
    public const string AffiliateKey = "affiliate";
    /// <summary>
    /// Gets or sets the name of the affiliate that referred the contact associated with the purchase.
    /// </summary>
    public string? Affiliate { get => AffiliateField.Value; set => AffiliateField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the name of the coupon corresponding to the coupon applied to the purchase.
    /// </summary>
    public ApiPropertyString CouponNameField => _couponNameField ??= new ApiPropertyString(this, CouponNameKey);
    private ApiPropertyString? _couponNameField;
    public const string CouponNameKey = "coupon_name";
    /// <summary>
    /// Gets or sets the name of the coupon corresponding to the coupon applied to the purchase.
    /// </summary>
    public string? CouponName { get => CouponNameField.Value; set => CouponNameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the code of the coupon corresponding to the coupon applied to the purchase.
    /// </summary>
    public ApiPropertyString CouponCodeField => _couponCodeField ??= new ApiPropertyString(this, CouponCodeKey);
    private ApiPropertyString? _couponCodeField;
    public const string CouponCodeKey = "coupon_code";
    /// <summary>
    /// Gets or sets the code of the coupon corresponding to the coupon applied to the purchase.
    /// </summary>
    public string? CouponCode { get => CouponCodeField.Value; set => CouponCodeField.Value = value; }

    
    
    /// <summary>
    /// The type of transaction.
    /// </summary>
    public enum TransactionType
    {
        OneTimePurchase = 0,
        Subscription = 1,
        PaymentPlan = 2,
        TrialPayment = 3
    }
    
    /// <summary>
    /// The status of the transaction.
    /// </summary>
    public enum TransactionStatus
    {
        Collections = 0,
        Paid = 1,
        Declined = 2,
        Voided = 3,
        Refunded = 4,
        WrittenOff = 5,
        Pending = 7
    }
}
