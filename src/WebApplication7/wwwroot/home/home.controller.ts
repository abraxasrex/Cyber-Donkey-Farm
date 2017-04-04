namespace mainApp.Controllers {
    export class mainController {
        public donkeys;
 
        public list() {
            this.$http.get('/api/values').then((result) => {
                this.donkeys = result.data;
            }).catch((e) => console.log(e));
        }

        public remove(id) {
            this.$http.delete('api/values/' + id).then((result) => {
                this.list();
            }).catch((e) => console.log(e));
        }

  

        public showModal(donkey) {
            console.log(donkey);
            let modal = this.$uibModal.open({
                templateUrl: '/modal/modal.view.html',
                controller: mainApp.Controllers.modalController,
                controllerAs: 'modal',
                resolve: {
                    _donkey: donkey
                }
            });
        }

        constructor(private $http: ng.IHttpService, private $uibModal: ng.ui.bootstrap.IModalService) {
            this.list();
        }
    }

   // module.controller('mainController', mainController);

}