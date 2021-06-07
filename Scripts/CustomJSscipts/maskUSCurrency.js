$(function () {
    $('.currency').maskMoney({ prefix: '$ ', allowNegative: true, thousands: ',', decimal: '.', affixesStay: true });
});