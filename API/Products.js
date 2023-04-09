class Products{
    constructor(ProductId,ProductName,ProductPrice,ProductViewer,Quantity,ProductCategory,Description,Date){
        this.ProductId = ProductId;
        this.ProductName =ProductName;
        this.ProductPrice = ProductPrice;
        this.ProductViewer = ProductViewer;
        this.Quantity = Quantity;
        this.ProductCategory =  ProductCategory;
        this.Date = Date;
    }
}

module.exports = Products;