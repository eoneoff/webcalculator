class Model {
    constructor(records, postUrl) {
        this.screen = ko.observable('0');
        this.history = ko.observableArray(records);
        this.error = ko.observable(false);
        this.postUrl = postUrl;
        this.saveError = ko.observable();
        this.offline = false;
    }

    numberClick(data, event) {
        let number = event.target.textContent;
        if (this.screen() != '0') {
            this.screen(this.screen() + number);
        } else {
            this.screen(number);
        }
        
    }

    clearClick() {
        this.error(false);
        this.screen('0');
    }

    deleteClick() {
        this.error(false);
        if (this.screen() != 0) {
            if (this.screen().length>1) {
                this.screen(this.screen().slice(0,-1));
            } else {
                this.screen('0');
            }
        }        
    }

    dotClick() {
        if (this.screen().indexOf('.') == -1) {
            this.screen(this.screen() + '.');
        }
    }

    operationClick(op) {
        this.screen(this.screen() + op);
    }

    operationEquals() {
        try {
            let result = eval(this.screen());
            if (result == Infinity || isNaN(result)) {
                throw 'error';
            }
            let expression = `${this.screen()}=${result}`;
            this.history.push(expression);
            this.screen(result.toString());
            if (!this.offline) {
                $.post(this.postUrl, { record: expression },
                    (data) => {
                        let result = $.parseJSON(data);
                        if (result.Success == 'false') {
                            this.saveError(result.Error);
                            $('#saveError').modal('show');
                        }
                    });
            }
        } catch (e) {
            this.error(true);
        }
    }

    showFromHistory(data) {
        let eq = data.slice(0, data.indexOf('='));
        this.screen(eq);
    }

    setOfflineMode() {
        this.offline = true;
    }
}