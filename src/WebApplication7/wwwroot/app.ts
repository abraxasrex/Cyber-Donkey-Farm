

namespace mainApp {
let module: ng.IModule = angular.module('mainApp', []);
    export class mainController {
        public world: string;
        public donkeys;
        public donkey;
        public _save() {
            this.$http.post('/api/values', this.donkey).then((donkey) => {
                console.log("cool.");
                this.list();
            }).catch((e) => { console.log(e); })
        }
        public list() {
            this.$http.get('/api/values').then((result) => {
                this.donkeys = result.data;
            }).catch((e) => console.log(e));;
        }
        constructor(private $http: ng.IHttpService) {
            this.world = 'world';
            this.donkey = {
                color: '',
                name: ''
            };;
            this.list();
        }
    }

    module.controller('mainController', mainController);

}

  //  console.log('boom!');
