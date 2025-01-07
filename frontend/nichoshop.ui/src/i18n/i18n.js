import { createI18n } from "vue-i18n";
import i18nMessages from "./i18nMessages";
const i18n = createI18n({
    locale: localStorage.getItem('language') || 'vi',
    messages: i18nMessages,
    legacy: false,
});
export default i18n;
