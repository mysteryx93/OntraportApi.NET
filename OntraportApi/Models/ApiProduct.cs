namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Product objects allow you to process transactions and order forms. 
/// </summary>
public class ApiProduct : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the user who controls the product. This field must contain a value for a product object to be saved properly.
    /// </summary>
    //public ApiProperty<int> OwnerField => _ownerField ?? (_ownerField = new ApiProperty<int>(this, OwnerKey));
    //private ApiProperty<int>? _ownerField;
    //public const string OwnerKey = "owner";
    ///// <summary>
    ///// Gets or sets the ID of the user who controls the product. This field must contain a value for a product object to be saved properly.
    ///// </summary>
    //public int? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the product's name.
    /// </summary>
    public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
    private ApiPropertyString? _nameField;
    public const string NameKey = "name";
    /// <summary>
    /// Gets or sets the product's name.
    /// </summary>
    public string? Name { get => NameField.Value; set => NameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the product's price.
    /// </summary>
    public ApiProperty<decimal> PriceField => _priceField ??= new ApiProperty<decimal>(this, PriceKey);
    private ApiProperty<decimal>? _priceField;
    public const string PriceKey = "price";
    /// <summary>
    /// Gets or sets the product's price.
    /// </summary>
    public decimal? Price { get => PriceField.Value; set => PriceField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the product was added.
    /// </summary>
    public ApiPropertyDateTime DateAddedField => _dateAddedField ??= new ApiPropertyDateTime(this, DateAddedKey);
    private ApiPropertyDateTime? _dateAddedField;
    public const string DateAddedKey = "date";
    /// <summary>
    /// Gets or sets the date the product was added.
    /// </summary>
    public DateTimeOffset? DateAdded { get => DateAddedField.Value; set => DateAddedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the product was last modified.
    /// </summary>
    public ApiPropertyDateTime DateLastModifiedField => _dateLastModifiedField ??= new ApiPropertyDateTime(this, DateLastModifiedKey);
    private ApiPropertyDateTime? _dateLastModifiedField;
    public const string DateLastModifiedKey = "dlm";
    /// <summary>
    /// Gets or sets the date the product was last modified.
    /// </summary>
    public DateTimeOffset? DateLastModified { get => DateLastModifiedField.Value; set => DateLastModifiedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the product has been deleted.
    /// </summary>
    public ApiPropertyBool DeletedField => _deletedField ??= new ApiPropertyBool(this, DeletedKey);
    private ApiPropertyBool? _deletedField;
    public const string DeletedKey = "deleted";
    /// <summary>
    /// Gets or sets whether or not the product has been deleted.
    /// </summary>
    public bool? Deleted { get => DeletedField.Value; set => DeletedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the product's description.
    /// </summary>
    public ApiPropertyString DescriptionField => _descriptionField ??= new ApiPropertyString(this, DescriptionKey);
    private ApiPropertyString? _descriptionField;
    public const string DescriptionKey = "description";
    /// <summary>
    /// Gets or sets the product's description.
    /// </summary>
    public string? Description { get => DescriptionField.Value; set => DescriptionField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the product's ID in other integrations.
    /// </summary>
    public ApiProperty<int> ExternalIdField => _externalIdField ??= new ApiProperty<int>(this, ExternalIdKey);
    private ApiProperty<int>? _externalIdField;
    public const string ExternalIdKey = "external_id";
    /// <summary>
    /// Gets or sets the product's ID in other integrations.
    /// </summary>
    public int? ExternalId { get => ExternalIdField.Value; set => ExternalIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the product group associated with the product.
    /// </summary>
    public ApiProperty<int> ProductGroupField => _productGroupField ??= new ApiProperty<int>(this, ProductGroupKey);
    private ApiProperty<int>? _productGroupField;
    public const string ProductGroupKey = "product_group";
    /// <summary>
    /// Gets or sets the ID of the product group associated with the product.
    /// </summary>
    public int? ProductGroup { get => ProductGroupField.Value; set => ProductGroupField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the product's code for integrations.
    /// </summary>
    public ApiPropertyString ExternalCodeField => _externalCodeField ??= new ApiPropertyString(this, ExternalCodeKey);
    private ApiPropertyString? _externalCodeField;
    public const string ExternalCodeKey = "sku";
    /// <summary>
    /// Gets or sets the product's code for integrations.
    /// </summary>
    public string? ExternalCode { get => ExternalCodeField.Value; set => ExternalCodeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the product can be included in tax calculations.
    /// </summary>
    public ApiPropertyIntBool TaxableField => _taxableField ??= new ApiPropertyIntBool(this, TaxableKey);
    private ApiPropertyIntBool? _taxableField;
    public const string TaxableKey = "taxable";
    /// <summary>
    /// Gets or sets whether or not the product can be included in tax calculations.
    /// </summary>
    public bool? Taxable { get => TaxableField.Value; set => TaxableField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the product's total income from transactions.
    /// </summary>
    public ApiProperty<decimal> TotalIncomeField => _totalIncomeField ??= new ApiProperty<decimal>(this, TotalIncomeKey);
    private ApiProperty<decimal>? _totalIncomeField;
    public const string TotalIncomeKey = "total_income";
    /// <summary>
    /// Gets or sets the product's total income from transactions.
    /// </summary>
    public decimal? TotalIncome { get => TotalIncomeField.Value; set => TotalIncomeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the product's total number of purchases from transactions.
    /// </summary>
    public ApiProperty<int> TotalPurchasesField => _totalPurchasesField ??= new ApiProperty<int>(this, TotalPurchasesKey);
    private ApiProperty<int>? _totalPurchasesField;
    public const string TotalPurchasesKey = "total_purchases";
    /// <summary>
    /// Gets or sets the product's total number of purchases from transactions.
    /// </summary>
    public int? TotalPurchases { get => TotalPurchasesField.Value; set => TotalPurchasesField.Value = value; }
}
