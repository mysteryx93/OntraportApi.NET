namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Purchases allow you to view and process purchases which have already been made. 
/// </summary>
public class ApiPurchase : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the contact associated with the purchase.
    /// </summary>
    public ApiProperty<long> ContactIdField => _contactIdField ??= new ApiProperty<long>(this, ContactIdKey);
    private ApiProperty<long>? _contactIdField;
    public const string ContactIdKey = "contact_id";
    /// <summary>
    /// Gets or sets the ID of the contact associated with the purchase.
    /// </summary>
    public long? ContactId { get => ContactIdField.Value; set => ContactIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the affiliate that referred the contact associated with the purchase.
    /// </summary>
    public ApiProperty<long> AffiliateIdField => _affiliateIdField ??= new ApiProperty<long>(this, AffiliateIdKey);
    private ApiProperty<long>? _affiliateIdField;
    public const string AffiliateIdKey = "affiliate_id";
    /// <summary>
    /// Gets or sets the ID of the affiliate that referred the contact associated with the purchase.
    /// </summary>
    public long? AffiliateId { get => AffiliateIdField.Value; set => AffiliateIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the purchased product.
    /// </summary>
    public ApiProperty<long> ProductIdField => _productIdField ??= new ApiProperty<long>(this, ProductIdKey);
    private ApiProperty<long>? _productIdField;
    public const string ProductIdKey = "product_id";
    /// <summary>
    /// Gets or sets the ID of the purchased product.
    /// </summary>
    public long? ProductId { get => ProductIdField.Value; set => ProductIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the user who controls the contact associated with the purchase.
    /// </summary>
    public ApiProperty<long> OwnerField => _ownerField ??= new ApiProperty<long>(this, OwnerKey);
    private ApiProperty<long>? _ownerField;
    public const string OwnerKey = "owner";
    /// <summary>
    /// Gets or sets the ID of the user who controls the contact associated with the purchase.
    /// </summary>
    public long? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the package the purchase belongs to. Default 0 if the purchase is not part of a package.
    /// </summary>
    public ApiProperty<long> PackageIdField => _packageIdField ??= new ApiProperty<long>(this, PackageIdKey);
    private ApiProperty<long>? _packageIdField;
    public const string PackageIdKey = "package_id";
    /// <summary>
    /// Gets or sets the ID of the package the purchase belongs to. Default 0 if the purchase is not part of a package.
    /// </summary>
    public long? PackageId { get => PackageIdField.Value; set => PackageIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the invoice the purchase belongs to. An invoice can contain multiple purchases.
    /// </summary>
    public ApiProperty<long> InvoiceIdField => _invoiceIdField ??= new ApiProperty<long>(this, InvoiceIdKey);
    private ApiProperty<long>? _invoiceIdField;
    public const string InvoiceIdKey = "invoice_id";
    /// <summary>
    /// Gets or sets the ID of the invoice the purchase belongs to. An invoice can contain multiple purchases.
    /// </summary>
    public long? InvoiceId { get => InvoiceIdField.Value; set => InvoiceIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the subscription the purchase belongs to. Default 0 if the product is not part of a subscription.
    /// </summary>
    public ApiProperty<long> SubscriptionIdField => _subscriptionIdField ??= new ApiProperty<long>(this, SubscriptionIdKey);
    private ApiProperty<long>? _subscriptionIdField;
    public const string SubscriptionIdKey = "subscription_id";
    /// <summary>
    /// Gets or sets the ID of the subscription the purchase belongs to. Default 0 if the product is not part of a subscription.
    /// </summary>
    public long? SubscriptionId { get => SubscriptionIdField.Value; set => SubscriptionIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the order the purchase belongs to. Default 0 if the product does not have an order associated with it.
    /// </summary>
    public ApiProperty<long> OrderIdField => _orderIdField ??= new ApiProperty<long>(this, OrderIdKey);
    private ApiProperty<long>? _orderIdField;
    public const string OrderIdKey = "order_id";
    /// <summary>
    /// Gets or sets the ID of the order the purchase belongs to. Default 0 if the product does not have an order associated with it.
    /// </summary>
    public long? OrderId { get => OrderIdField.Value; set => OrderIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the affiliate to be credited for the purchase.
    /// </summary>
    public ApiProperty<long> OprIdField => _oprIdField ??= new ApiProperty<long>(this, OprIdKey);
    private ApiProperty<long>? _oprIdField;
    public const string OprIdKey = "oprid";
    /// <summary>
    /// Gets or sets the ID of the affiliate to be credited for the purchase.
    /// </summary>
    public long? OprId { get => OprIdField.Value; set => OprIdField.Value = value; }
    
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
    public ApiProperty<long> CouponIdField => _couponIdField ??= new ApiProperty<long>(this, CouponIdKey);
    private ApiProperty<long>? _couponIdField;
    public const string CouponIdKey = "coupon_id";
    /// <summary>
    /// Gets or sets the ID of the coupon applied to the purchase.
    /// </summary>
    public long? CouponId { get => CouponIdField.Value; set => CouponIdField.Value = value; }
    
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the coupon code corresponding to the coupon used, if a coupon was applied to the purchase.
    /// </summary>
    public ApiProperty<long> CouponCodeIdField => _couponCodeIdField ??= new ApiProperty<long>(this, CouponCodeIdKey);
    private ApiProperty<long>? _couponCodeIdField;
    public const string CouponCodeIdKey = "coupon_code_id";
    /// <summary>
    /// Gets or sets the ID of the coupon code corresponding to the coupon used, if a coupon was applied to the purchase.
    /// </summary>
    public long? CouponCodeId { get => CouponCodeIdField.Value; set => CouponCodeIdField.Value = value; }
    
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
