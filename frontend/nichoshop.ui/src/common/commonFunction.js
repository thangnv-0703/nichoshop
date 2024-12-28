import enumeration from "./enumeration";

export default {
    getDisplayedPrice: (price, currency) => {
        let displayedCurrency;
        if (currency === enumeration.currency.USD) {
            displayedCurrency = '$';
        } else if (currency === enumeration.currency.EUR) {
            displayedCurrency = '€';
        } else if (currency === enumeration.currency.VND) {
            displayedCurrency = '₫';
        } else {
            displayedCurrency = currency;
        }
        return displayedCurrency + price.toLocaleString("vi-VN");
    }
};;
