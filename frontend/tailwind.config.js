/** @type {import('tailwindcss').Config} */
import forms from '@tailwindcss/forms';

export default {
  content: [
    "./index.html",
    "./src/**/*.{vue, js,ts,jsx,tsx}",
  ],
  theme: {
    colors: {
      transparent: 'transparent',
      current: 'currentColor',
      'white': '#FFFFFF',
      'dark-blue': '#0D1B2A',
      'blue': '#2E68BE',
      'light-blue': '#418dff',
      'gray': '#F6F6F5',
      'footer-color': '#4B5563',
      'red': '#dc2626',
    },
    extend: {},
  },
  plugins: [
    forms,
  ],
}

