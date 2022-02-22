var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct: null,
        newStock: {
            proizvoId: 0,
            kolicina: 1,
            productName:"",
        },
        newStockSendFormat: {
            proizvodId: 0,
            kolicina: 1,
        },
    },
    mounted() {
        this.getStock();
    },
    methods: {
        getStock() {
            this.loading = true;
            axios.get('/Admins/stocks')
                .then(res => {
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateStock() {
            this.loading = true;
            console.log(this.products);
            const sendVar = {
                stock: this.selectedProduct.stock.map(x => {
                    return {
                        id: x.id,
                        kolicina: this.newStock.kolicina,
                        proizvodId: this.selectedProduct.id,
                    }
                })
            };
            console.log("SEND VARIJABLA 22 ", sendVar);
            axios.put('/Admins/stocks', sendVar)
                .then(res => {

                    this.getStock();
                    /*this.selectedProduct.stock.splice(index, 1);*/
                })
                .catch(err => {
                    console.log(err);
                })
                .finally(() => {
                    this.loading = false;
                });
        },
        deleteStock(id, index) {
            this.loading = true;
            axios.delete('/Admins/stocks/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addStock() {
            this.loading = true;
            this.newStockSendFormat = {
                proizvodId : this.newStock.proizvoId,
                kolicina: this.newStock.kolicina
            };
            axios.post('/Admins/stocks', this.newStockSendFormat)
                .then(res => {
                    this.products.push({
                        stock: [res.data]
                        });
                })
                .catch(err => {
                    console.log(err);
                })
                .finally(() => {
                    this.loading = false;
                    this.getStock();
                });
        },
        selectProduct(product) {
            this.selectedProduct = product;
            
            this.newStock.proizvoId = product.id;
            this.newStock.productName = product.stock[0].productName;
            this.newStock.kolicina = product.stock[0].kolicina;
        }
    }
})