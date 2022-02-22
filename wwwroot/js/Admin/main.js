var app = new Vue({
    el: '#app',
    data: {
        price: 0,
        indexObject: 0,
        showPrice: true,
        loading: false,
        productModel: {
            productName: "productName",
            productPrice: "productPrice",
            id: 0,
        },
        products: [],
    },
    mounted() {
        this.getProducts();
    },
    methods: {
        togglePrice: function () {
            this.showPrice = !this.showPrice;
        },
        getProducts() {
            this.loading = true;
            axios.get('/Admins/products').then(r => {
                console.log(r);
                this.products = r.data;
            }).catch(err => {
                console.log(err);
            }).finally(() => {
                this.loading = false;
            });
        },
        getProduct(id) {
            this.loading = true;
            axios.get('/Admins/products/' + id).then(r => {
                console.log(r);
                this.productModel = r.data;
            }).catch(err => {
                console.log(err);
            }).finally(() => {
                this.loading = false;
            });
        },
        editProduct(product, index) {
            this.loading = true;
            
            this.indexObject = index;
            this.productModel = {
                id: product.id,
                productName: product.productName,
                productPrice: product.productPrice
            };
            /*this.getProduct(product.id);*/
        },
        updateProduct() {
            this.loading = true;
            console.log("UPDATE LOG",this.productModel);
            axios.put('/Admins/products', this.productModel).then(r => {
                console.log(r);
                this.products.splice(this.indexObject, 1, r.data);
            }).catch(err => {
                console.log(err);
            }).finally(() => {
                this.loading = false;
            });
        },
        deleteProduct(id, index) {
            this.loading = true;
            this.indexObject = index;
            axios.delete('/Admins/products/' + id).then(r => {
                console.log(r);
                this.products.splice(index, 1);
            }).catch(err => {
                console.log(err);
            }).finally(() => {
                this.loading = false;
            });
        },
        createProduct() {
            this.loading = true;
            const payload = {
                productName: this.productModel.productName,
                productPrice: this.productModel.productPrice,
                id: this.productModel.id,
            }
            console.log(payload);
            axios.post('/Admins/products', payload).then(r => {
                this.products.push(this.productModel);
                console.log(r);
            })
                .catch(err => {
                    console.log(this.products);
                console.log(err);
                }).finally(() => {
                this.loading = false;
            });
        },
    },
    computed: {
        formatPrice: function () {
            return "€" + this.price;
        }
    }
});