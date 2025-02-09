import { defineConfig } from "vite";
import path from "path";
import vue from "@vitejs/plugin-vue";
import Components from "unplugin-vue-components/vite";
import { PrimeVueResolver } from "@primevue/auto-import-resolver";
import eslintPlugin from "vite-plugin-eslint";

export default defineConfig({
  base: "/",
  build: {
    chunkSizeWarningLimit: 1024, // Set to 1024 KB (1MB) or higher to suppress warnings
  },
  plugins: [
    vue(),
    Components({
      // Tự động import các component từ thư mục components/
      dirs: ['src/components'],
      extensions: ['vue'],
      dts: true, // Tạo file types tự động nếu bạn dùng TypeScript
      resolvers: [PrimeVueResolver()],
    }),
    // eslintPlugin(),
  ],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
});
