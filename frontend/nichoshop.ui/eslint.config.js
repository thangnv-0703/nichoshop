import vue from "eslint-plugin-vue";
import vueParser from "vue-eslint-parser";
import js from "@eslint/js";

export default [
  {
    files: ["**/*.vue"],
    languageOptions: {
      parser: vueParser
    },
    plugins: { vue },
    rules: {
      ...vue.configs["vue3-recommended"].rules,
      "vue/no-unused-vars": "error",
      "vue/multi-word-component-names": "off",
      "vue/html-indent": ["error", 2]
    }
  },
  {
    files: ["**/*.js"],
    languageOptions: {
      parserOptions: { ecmaVersion: "latest" }
    },
    plugins: { js }
  }
];
