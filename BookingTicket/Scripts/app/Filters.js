var upperText = function () {
    return function (input) {
        if (!input) {
            return "";
        }
        return input.toUpperCase();
    };
}
upperText.$inject = [];

var trustHtml = function ($sce) {
    return function (input) {
        if (!input) {
            return "";
        }
        return $sce.trustAsHtml(input);
    };
}
trustHtml.$inject = ["$sce"];

var dateFormat = function ($filter) {
    return function (input) {
        if (!input) {
            return "";
        }

        var resultDate;

        if (input instanceof Date) {
            resultDate = input;
        } else {
            var temp = input.replace(/\//g, "").replace("(", "").replace(")", "").replace("Date", "").replace("+0700", "").replace("-0000", "");

            if (input.indexOf("Date") > -1) {
                resultDate = new Date(+temp);
            } else {
                resultDate = new Date(temp);
            }

            var utc = resultDate.getTime() + (resultDate.getTimezoneOffset() * 60000);

            // create new Date object for different city
            // using supplied offset
            var resultDate = new Date(utc + (3600000 * 7));
        }

        return $filter("date")(resultDate, "dd/MM/yyyy");
    };
}
dateFormat.$inject = ["$filter"];

var dateJSFormat = function ($filter) {
    return function (input) {
        if (!input) { return ""; }
        input = new Date(input);
        function pad(s) { return (s < 10) ? '0' + s : s; }
        return [pad(input.getDate()), pad(input.getMonth() + 1), input.getFullYear()].join('/');
    }
}
dateJSFormat.$inject = ["$filter"];

var hiddenCharFirst = function ($filter) {
    return function (input) {
        if (!input) { return ""; }
        //input = new Date(input);
        //function pad(s) { return (s < 10) ? '0' + s : s; }
        input = input.trim();
        var res = input.substring(input.length - 4, input.length);
        return "*********" + res;//[pad(input.getDate()), pad(input.getMonth() + 1), input.getFullYear()].join('/');
    }
}
hiddenCharFirst.$inject = ["$filter"];

var dateTimeFormat = function ($filter) {
    function getCurrentDate() {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = "0" + dd;
        }

        if (mm < 10) {
            mm = "0" + mm;
        }

        today = dd + "/" + mm + "/" + yyyy;
        return today;
    };

    return function (input) {
        if (!input) { return ""; }
        var temp = input.replace(/\//g, "").replace("(", "").replace(")", "").replace("Date", "").replace("+0700", "").replace("-0000", "");

        var date;
        var resultDate;

        if (input.indexOf("Date") > -1) {

            resultDate = new Date(+temp);
            date = $filter("date")(resultDate, "dd/MM/yyyy");


            var utc = resultDate.getTime() + (resultDate.getTimezoneOffset() * 60000);

            // create new Date object for different city
            // using supplied offset
            resultDate = new Date(utc + (3600000 * 7));

            if (getCurrentDate() === date) {
                return $filter("date")(resultDate, "HH:mm") + " Hôm nay";
            } else {
                return $filter("date")(resultDate, "HH:mm ") + " " + $filter("date")(resultDate, "dd/MM/yyyy");
            }

        } else {

            date = $filter("date")(new Date(temp), "dd/MM/yyyy");

            if (getCurrentDate() === date) {
                return "Hôm nay";
            } else {
                var utc = date.getTime() + (date.getTimezoneOffset() * 60000);

                // create new Date object for different city
                // using supplied offset
                resultDate = new Date(utc + (3600000 * 7));
                return $filter("date")(resultDate, "dd/MM/yyyy");
            }
        }
    };
}

dateTimeFormat.$inject = ["$filter"];

var timeFormat = function ($filter) {
    return function (input) {
        if (!input) { return ""; }
        var temp = input.replace(/\//g, "").replace("(", "").replace(")", "").replace("Date", "").replace("-0000", "");
        var resultDate = new Date(+temp);
        var utc = resultDate.getTime() + (resultDate.getTimezoneOffset() * 60000);

        // create new Date object for different city
        // using supplied offset
        resultDate = new Date(utc + (3600000 * 7));
        var _date = $filter("date")(resultDate, "hh:mm");
        return _date;
    };
}
var timeFormatStoreRent = function ($filter) {
    return function (input) {
        if (!input) { return ""; }
        var temp = input.replace(/\//g, "").replace("(", "").replace(")", "").replace("Date", "").replace("-0000", "");
        var resultDate = new Date(+temp);
        var utc = resultDate.getTime() + (resultDate.getTimezoneOffset() * 60000);
        // create new Date object for different city
        // using supplied offset
        resultDate = new Date(utc + (3600000 * 7));
        var now = new Date();
        var day = resultDate.getDate();
        var month = resultDate.getMonth();
        var year = resultDate.getYear();
        var _date = $filter("date")(resultDate, "HH:mm");
        if (now.getYear() == resultDate.getYear()) {
            if (now.getMonth() == resultDate.getMonth()) {
                var div = now.getDate() - resultDate.getDate();
                if (div == 0) {
                    _date += " Hôm nay";
                } else if (div == 1) {
                    _date += " Hôm qua";
                } else {
                    _date += " " + $filter("date")(resultDate, "dd/MM/yyyy");
                }
            } else {
                _date += " " + $filter("date")(resultDate, "dd/MM/yyyy");
            }
        } else {
            _date += " " + $filter("date")(resultDate, "dd/MM/yyyy");
        }

        return _date;
    };
}
timeFormatStoreRent.$inject = ["$filter"];

var propsFilter = function () {
    function change_alias(alias) {
        var str = alias;
        str = str.toLowerCase();
        str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ  |ặ|ẳ|ẵ/g, "a");
        str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
        str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
        str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ  |ợ|ở|ỡ/g, "o");
        str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
        str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
        str = str.replace(/đ/g, "d");
        str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\"| |\"|\&|\#|\[|\]|~|$|_/g, "-");
        /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
        str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
        str = str.replace(/^\-+|\-+$/g, "");
        //cắt bỏ ký tự - ở đầu và cuối chuỗi 
        return str;
    }

    return function (items, props) {
        var out = [];
        if (angular.isArray(items)) {
            items.forEach(function (item) {
                var itemMatches = false;

                var keys = Object.keys(props);
                for (var i = 0; i < keys.length; i++) {
                    var prop = keys[i];
                    if (item[prop]) {
                        var text = props[prop].toLowerCase();
                        if (change_alias(item[prop].toString().toLowerCase()).indexOf(change_alias(text)) !== -1) {
                            itemMatches = true;
                            break;
                        }
                    }
                }
                if (itemMatches) {
                    out.push(item);
                }
            });
        } else {
            out = items;
        }
        return out;
    };
};

propsFilter.$inject = [];

//var currency = function ($locale) {
//    var formats = $locale.NUMBER_FORMATS;

//    return function (amount, currencySymbol, decimalPlaces, isRoundDown) {
//        debugger;
//        if (currencySymbol) {
//            currencySymbol = formats.CURRENCY_SYM;
//        }

//        return formatNumber(amount, formats.PATTERNS[1], formats.GROUP_SEP, formats.DECIMAL_SEP, decimalPlaces, isRoundDown).replace(/\u00A4/g, currencySymbol);
//    }
//}

// currency.$inject = ["$locale"];

var telFormat = function () {
    return function (tel) {
        if (!tel) { return ""; }

        var value = tel.toString().trim().replace(/^\+/, "");

        if (value.match(/[^0-9]/)) {
            return tel;
        }

        var city, number;

        switch (value.length) {
            case 1:
            case 2:
            case 3:
                city = value;
                break;

            default:
                city = value.slice(0, 4);
                number = value.slice(4);
        }

        if (number) {
            if (number.length > 4) {
                number = number.slice(0, 4) + "." + number.slice(4, 7);
            }
            return (city + "." + number).trim();
        } else {
            return city;
        }
    };
};

telFormat.$inject = [];

var webstatus = function () {
    return function (webStatus) {
        switch (webStatus) {
            case 1:
            case 7:
                return "Không kinh doanh"; // Không kinh doanh
            case 2:
                return "Hàng sắp về"; // Hàng sắp về
            case 3:
                return "Chỉ bản online"; // Chỉ bản online
            case 4:
                return "Còn hàng"; // Còn hàng
            case 5:
                return "Tạm thời hết hàng"; // Tạm thời hết hàng
            case 8:
                return "Giao hàng từ 2 - 7 ngày"; // Giao hàng từ 2 - 7 ngày
            case 9:
                return "Mới"; // Mới
            case 6:
            case 10:
                return "Sắp hết hàng và có thể ngưng kinh doanh"; // Sắp hết hàng và có thể ngưng kinh doanh
            default:
                return "Ngừng kinh doanh";
        }
    }
}

webstatus.$inject = [];

var shortenedName = function () {
    var processName;

    processName = function (name) {
        var result = "";

        if (name) {
            var preHyphen = "";
            var hyphenIndex = name.indexOf("-");

            if (hyphenIndex > 0) {
                var postHyphenIndex = hyphenIndex;

                if (name.charAt(postHyphenIndex + 1) == " ") {
                    ++postHyphenIndex;
                }

                preHyphen = name.substring(0, postHyphenIndex + 1);
                name = name.substring(postHyphenIndex + 1, name.length);
                result = preHyphen;
            }

            var arrNames = name.split(" ");

            for (var i = 0; i < arrNames.length - 1; ++i) {
                var temp = arrNames[i];

                if (!isNaN(temp)) {
                    result += temp + " ";
                } else {
                    result += temp.charAt(0) + ".";
                }
            }

            result += arrNames[arrNames.length - 1];
        }

        return result;
    }

    return function (name) {
        var result = "";

        if (name) {
            var lstString;

            if (name.indexOf("(") > -1) {
                lstString = name.split("(");
            } else {
                lstString = [];
                lstString.push(name);
            }

            var trimedList = [];

            lstString.forEach(function (current) {
                current = current.trim();

                if (current.length > 0) {
                    trimedList.push(current);
                }
            });

            lstString = trimedList;

            lstString.forEach(function (current) {
                var temp = ""

                if (current.indexOf(")") > -1) {
                    temp = "(" + processName(current.substring(0, current.length - 1)) + ")";
                } else {
                    temp = processName(current);
                }

                result += temp + " ";
            });

            result = result.substring(0, result.length);
        }

        return result;
    }
}

shortenedName.$inject = [];

var numberFormat = function () {
    return function (n, decPlaces, thouSeparator, decSeparator, trimZero, emptyWhenZero) {
        try {
            if (isNaN(n)) {
                return 0;
            }

            if (n == 0) {
                if (emptyWhenZero == "true") {
                    return "";
                } else if (trimZero == "true") {
                    return 0;
                }
            }

            var decPlaces = isNaN(decPlaces = Math.abs(decPlaces)) ? 2 : decPlaces,
                decSeparator = decSeparator == undefined ? "." : decSeparator,
                thouSeparator = thouSeparator == undefined ? "," : thouSeparator,
                sign = n < 0 ? "-" : "",
                i = parseInt(n = Math.abs(+n || 0).toFixed(decPlaces)) + "",
                j = (j = i.length) > 3 ? j % 3 : 0;
            return sign + (j ? i.substr(0, j) + thouSeparator : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thouSeparator) + (decPlaces ? decSeparator + Math.abs(n - i).toFixed(decPlaces).slice(2) : "");
        } catch (e) {
            return n;
        }
    }
};

numberFormat.$inject = [];

var numberSerialFormat = function () {
    return function (input) {
        var first = input.substr(0, 4);
        var second = input.substr(4, 4);
        var third = input.substr(8, (input.length - 8));
        return first + " - " + second + " - " + third;
    }
};

var roundFloatNumber = function ($filter) {
    return function (input) {
        if (!input) { return ""; }
        return Number((input).toFixed(2));
    };
}

roundFloatNumber.$inject = ["$filter"];