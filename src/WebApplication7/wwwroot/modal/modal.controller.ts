
namespace mainApp.Controllers {

    export class modalController {
        public donkey;
        public message = "foobar";

        public edit(donkey) {
            this.$http.put('api/values/' + donkey.id, donkey).then((result) => {
                // this.list();
            }).catch((e) => console.log(e));
        }

        public ok(donkey) {
            this.edit(donkey)
            this.$uibModalInstance.close();
        }

constructor(
        private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        public _donkey: Object,
        private $http: ng.IHttpService) {
             this.donkey = _donkey;
             console.log("hello, ", _donkey);
}   
    }
}