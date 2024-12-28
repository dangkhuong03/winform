import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
  plugins: [vue()],
  server: {
    // Cấu hình port nếu cần
    port: 3000,
  },
  build: {
    outDir: '../wwwroot/dist', // Đường dẫn đầu ra
  }
});