(function () {
    app.factory('BookingFactory', ['$http', 'CommonFactory', function ($http, CommonFactory) {
        var factory = {};
        var URL = "/LeftSection/";

        factory.GetAllSeatOfTimeGo = function (intDateGoID, intStationID, intRouteID, callback) {
            var datasend = JSON.stringify({
                intDateGoID: intDateGoID,
                intStationID: intStationID,
                intRouteID: intRouteID
            });

            CommonFactory.PostDataAjax(URL + "GetAllSeatOfTimeGo", datasend,
                function (err) {
                    
                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    
                    callback(error);
                });
        }

        factory.GetAllSeatCancelOfTimeGo = function (intDateGoID, intStationID, callback) {
            var datasend = JSON.stringify({
                intDateGoID: intDateGoID,
                intStationID: intStationID
            });

            CommonFactory.PostDataAjax(URL + "GetAllSeatCancelOfTimeGo", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {

                    callback(error);
                });
        }

        factory.SendRequestToPrintSvc = function (objTicket, callback) {
            $.ajax({
                type: "POST",
                url: UrlPrinterService,
                timeout: 15000,
                cache: true,
                crossDomain: true,
                data: {
                    StationFromName: objTicket.StationFromName,
                    StationToName: objTicket.StationToName,
                    GoDate: objTicket.GoDate,
                    GoTime: objTicket.GoTime,
                    Description: objTicket.Description,
                    FullName: objTicket.FullName,
                    Driver: objTicket.Driver,
                    CarNumber: objTicket.CarNumber
                },
                processData: true,
                beforeSend: function () { },
                success: function (response) {
                    callback(response);
                },
                error: function (e) {
                    setTimeout(function () {
                        callback(null);
                    }, 10);
                }
            });
        }

        factory.GetRouteByStation = function (intStationFrom, intStationTo, callback) {
            var datasend = JSON.stringify({
                intStationFrom: intStationFrom, intStationTo: intStationTo
            });

            CommonFactory.PostDataAjax("/Ticket/GetRouteByStation", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {

                    callback(error);
                });
        }

        factory.Booking = function (listSeatID, callback) {
            var datasend = JSON.stringify({
                listSeatID: listSeatID
            });

            CommonFactory.PostDataAjax("/Ticket/BookingTicket", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        factory.MoveSeat = function (intDateGoDetailIDFrom, intDateGoDetailIDTo, callback) {
            var datasend = JSON.stringify({
                intDateGoDetailIDFrom: intDateGoDetailIDFrom,
                intDateGoDetailIDTo: intDateGoDetailIDTo
            });

            CommonFactory.PostDataAjax("/Ticket/MoveSeat", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        factory.GetListPickup = function (intCarDateGoID, callback) {
            var datasend = JSON.stringify({
                intCarDateGoID: intCarDateGoID
            });

            CommonFactory.PostDataAjax("/Ticket/GetListPickup", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        factory.GetListTransit = function (intCarDateGoID, callback) {
            var datasend = JSON.stringify({
                intCarDateGoID: intCarDateGoID
            });

            CommonFactory.PostDataAjax("/Ticket/GetListTransit", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        factory.GetLogByDateGoDetailID = function (intDateGoDetailID, callback) {
            var datasend = JSON.stringify({
                intDateGoDetailID: intDateGoDetailID
            });

            CommonFactory.PostDataAjax("/Ticket/GetLogByDateGoDetailID", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        factory.GetLogCustomerByDateGoDetailID = function (strPhone, callback) {
            var datasend = JSON.stringify({
                strPhone: strPhone
            });

            CommonFactory.PostDataAjax("/Ticket/GetLogCustomerByDateGoDetailID", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {
                    callback(error);
                });
        }

        factory.Update = function (model, callback) {
            var datasend = JSON.stringify(model);
            
            CommonFactory.PostDataAjax("/Ticket/Update", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {

                    callback(error);
                });
        }

        factory.UpdateSeatsCancel = function (model, strCarDateGoDetailID, callback) {
            
            var datasend = JSON.stringify({
                model:model,
                strCarDateGoDetailID: strCarDateGoDetailID
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateSeatsCancel", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {

                    callback(error);
                });
        }

        factory.GetAllStation = function (intSortDesc,callback) {
            var datasend = JSON.stringify({
                intSortDesc: intSortDesc
            });

            CommonFactory.PostDataAjax("/Ticket/GetAllStation", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {

                    callback(error);
                });
        }

        factory.GetAllPickupAddress = function (type, routeID, callback) {
            var datasend = JSON.stringify({
                type: type,
                routeID: routeID
            });

            CommonFactory.PostDataAjax("/Ticket/GetAllPickupAddress", datasend,
                function (err) {

                },
                function (response) {
                    callback(response);
                },

                function (error) {

                    callback(error);
                });
        }

        factory.UpdateStatusPayment = function (lstCarDateGoDetailID, iStatusID, RouteID, callback) {
            var datasend = JSON.stringify({
                lstCarDateGoDetailID: lstCarDateGoDetailID,
                iStatusID: iStatusID,
                RouteID: RouteID
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateStatusPayment", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        factory.DeleteTicket = function (lstCarDateGoDetailID, strNoteChange, callback) {
            var datasend = JSON.stringify({
                lstCarDateGoDetailID: lstCarDateGoDetailID,
                strNoteChange: strNoteChange
            });

            CommonFactory.PostDataAjax("/Ticket/DeleteTicket", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        factory.UpdateOrderTransit = function (lstCarDateGoDetailID, lstIndex, callback) {
            var datasend = JSON.stringify({
                strID: lstCarDateGoDetailID,
                intIndex: lstIndex
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateOrderTransit", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        factory.UpdateOrderPickup = function (lstCarDateGoDetailID, lstIndex, callback) {
            var datasend = JSON.stringify({
                strID: lstCarDateGoDetailID,
                intIndex: lstIndex
            });

            CommonFactory.PostDataAjax("/Ticket/UpdateOrderPickup", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        factory.GetCarByID = function (intCarDateGoID, callback) {
            var datasend = JSON.stringify({
                intCarDateGoID: intCarDateGoID
            });

            CommonFactory.PostDataAjax("/Ticket/GetCarByID", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }

        factory.CarIsGo = function (intCarID, callback) {
            var datasend = JSON.stringify({
                intCarID: intCarID
            });

            CommonFactory.PostDataAjax("/Ticket/CarIsGo", datasend,
                function (err) {
                },
                function (response) {
                    callback(response);
                },
                function (error) {
                    callback(error);
                });
        }
        

        return factory;
    }])

})();
