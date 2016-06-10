System.register(['@angular/core', '@angular/http', 'rxjs/Observable'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, http_1, Observable_1;
    var PlayListService;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            }],
        execute: function() {
            PlayListService = (function () {
                function PlayListService(_http) {
                    this._http = _http;
                    this._settingUrl = "https://api.spotify.com/v1/search?";
                }
                PlayListService.prototype.getWholeList = function () {
                    return this._http.get(this._settingUrl + "q=opeth&type=track")
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                PlayListService.prototype.getListByFreeText = function (inText, inNumber) {
                    var limit = 50;
                    if (inNumber > 0) {
                        limit = inNumber;
                    }
                    return this._http.get(this._settingUrl + "q=" + inText + "&type=track&offset=100&limit=" + limit)
                        .map(function (response) { return response.json(); })
                        .catch(this.handleError);
                };
                PlayListService.prototype.handleError = function (error) {
                    console.error(error);
                    return Observable_1.Observable.throw(error.json().error || 'Server error');
                };
                PlayListService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], PlayListService);
                return PlayListService;
            }());
            exports_1("PlayListService", PlayListService);
        }
    }
});
//# sourceMappingURL=playlist.service.js.map