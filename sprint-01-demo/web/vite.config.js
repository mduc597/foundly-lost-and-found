import { defineConfig } from 'vite';
export default defineConfig({
  server: {
    host:'0.0.0.0', port:5181, strictPort:true,
    proxy:{ '/api': { target: process.env.API_PROXY_TARGET || 'http://localhost:8081', changeOrigin:true } }
  }
});
