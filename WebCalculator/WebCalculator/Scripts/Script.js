class Model {
    constructor() {
        this.screen = ko.observable(0);
        this.operation = ko.observableArray();
        this.history = ko.observableArray();
    }

    numberClick(data, event) {
        let number = event.target.textContent;
        if (this.screen() != 0) {
            this.screen(this.screen() + number);
        } else {
            this.screen(number);
        }
        
    }

    clearClick() {
        this.screen(0);
    }

    deleteClick() {
        if (this.screen() != 0) {
            if (this.screen().length>1) {
                this.screen(this.screen().slice(0,-1));
            } else {
                this.screen(0);
            }
        }        
    }

    dotClick() {
        if (this.screen().indexOf('.') == -1) {
            this.screen(this.screen() + '.');
        }
    }

    operationClick(op) {
        this.operation.push(this.screen());
        this.operation.push(op);
        this.screen(0);
    }

    operationEquals() {
        this.operation.push(this.screen());
        let result = eval(this.operation().join(''));
        this.operation.push('=');
        this.operation.push(result);
        this.screen(result);
        this.history.push(this.operation());
        this.operation.removeAll();
    }
}