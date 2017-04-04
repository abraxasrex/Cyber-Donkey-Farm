namespace mainApp.Controllers {
    export class addController {
        public donkey;
        public _save() {
            this.$http.post('/api/values', this.donkey).then((donkey) => {
                console.log("cool.");
                this.$state.go('Home');
            }).catch((e) => { console.log(e); })
        }
        public leave(state) {

        }
        constructor(
            private $http: ng.IHttpService,
            private $state: ng.ui.IStateService) {
            this.donkey = {
                color: '',
                name: ''
            };
        }
    }
}