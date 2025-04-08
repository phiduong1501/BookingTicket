var app = angular.module("BookingTicketApp", ['kendo.directives', 'ngRoute', 'ngAnimate', 'ngSanitize']);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "/Home/Home"
            //controller: HomeController
        })
        .when("/booking/:intDateGoID/:stationFromID", {
            templateUrl: "/Ticket/Booking"
        })
        .when("/ticketlist/:intDateGoID/:stationFromID", {
            templateUrl: "Ticket/TicketListOfRoute"
        })
        .when("/payback/:intDateGoID/:stationFromID", {
            templateUrl: "Ticket/PayBack"
        })
        .when("/transit/:intDateGoID/:stationFromID", {
            templateUrl: "Ticket/Transit"
        })
        .when("/managementcar", {
            templateUrl: "Ticket/ManagementCar"
        })
        .when("/managementstation", {
            templateUrl: "Ticket/ManagementStation"
        })
        .when("/managementtime", {
            templateUrl: "Ticket/ManagementTime"
        })
        .when("/managementroute", {
            templateUrl: "Ticket/ManagementRoute"
        })
        .when("/managementpickup", {
            templateUrl: "Ticket/ManagementPickup"
        })
         .when("/changepassword", {
             templateUrl: "Account/ChangePassword"
         })
        .when("/managementaccount", {
            templateUrl: "Ticket/ManagementAccount"
        })
        .when("/managementcompany", {
            templateUrl: "Company/List"
        })
        .when("/register", {
            templateUrl: "Account/Register"
        });
});

var addFilter = function (name, filter) {
    try {
        app.filter(name, filter);
    } catch (e) {
        console.log(JSON.stringify(e));
    }
}

Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + parseInt(days));
    this.setHours(0);
    return this;
};

addFilter("dateFormat", dateFormat);
addFilter("dateJSFormat", dateJSFormat);
addFilter("dateTimeFormat", dateTimeFormat);
addFilter("timeFormatStoreRent", timeFormatStoreRent);
addFilter("trustHtml", trustHtml);
addFilter("timeFormat", timeFormat);
addFilter("propsFilter", propsFilter);
//addFilter("currency", currency);
addFilter("tel", telFormat);
addFilter("webstatus", webstatus);
addFilter("shortenedName", shortenedName);
addFilter("numberFormat", numberFormat);
addFilter("numberSerialFormat", numberSerialFormat);
addFilter("roundFloatNumber", roundFloatNumber);
//addFilter("hiddenCharFirst", hiddenCharFirst);
addFilter("upperText", upperText);
