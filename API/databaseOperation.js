var config = require('./databaseConfig');
const sql = require('mssql');

async function dangnhap(user,pass){
    try {
        console.log(user+' '+pass)
        let pool = await sql.connect(config);
        let products = await pool.request()
        .input('user', sql.VarChar, user)
        .input('pass',sql.VarChar,pass)
        .query("SELECT * from TaiKhoan where TenTaiKhoan = @user and MatKhau = @pass");
        var taikhoan = products.recordsets[0][0];
        if(taikhoan == null){
            return false;
        }
        return true;
    }
    catch (error) {
        console.log(error);
    }
}
async function dangnhapshiper(user,pass){
    try {
        console.log('Đang xử lí đăng nhập...')
        console.log('Tài khoản: '+user+'\n Mật khẩu: '+pass)
        let pool = await sql.connect(config);
        let products = await pool.request()
        .input('user', sql.VarChar, user)
        .input('pass',sql.VarChar,pass)
        .query("exec TaiKhoan_DangNhap_Shiper @user,@pass");
        var taikhoan = products.recordsets[0][0];
        console.log('Kết quả: '+taikhoan)
        return taikhoan;
    }
    catch (error) {
        console.log(error);
    }
}
async function getOrders() {
    try {
        let pool = await sql.connect(config);
        let products = await pool.request().query("SELECT * from TaiKhoan");
        return products.recordsets;
    }
    catch (error) {
        console.log(error);
    }
}

async function getOrder(productId) {
    try {
        let pool = await sql.connect(config);
        let product = await pool.request()
            .input('input_parameter', sql.Int, productId)
            .query("SELECT * from Products where ProductId = @input_parameter");
        return product.recordsets;

    }
    catch (error) {
        console.log(error);
    }
}


async function addOrder(product) {

    try {
        let pool = await sql.connect(config);
        let insertProduct = await pool.request()
            .input('ProductId', sql.Int, product.ProductId)
            .input('ProductName', sql.NVarChar, product.ProductName)
            .input('ProductPrice', sql.Float, product.ProductPrice)
            .input('ProductViewer', sql.Int, product.ProductViewer)
            .input('Quantity', sql.Int, product.Quantity)
            .input('ProductCategory', sql.Int, product.ProductCategory)
            .input('Date', sql.DateTime, product.Date)
            .execute('InsertOrders');
        return insertProduct.recordsets;
    }
    catch (err) {
        console.log(err);
    }
}






module.exports = {
    getOrders: getOrders,
    getOrder : getOrder,
    addOrder : addOrder,
    dangnhap : dangnhap,
    dangnhapshiper:dangnhapshiper
}