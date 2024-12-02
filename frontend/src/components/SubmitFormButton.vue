<script setup>
  defineProps({
    title: String,
    isDisabled: {
      type: Boolean,
      default: false,
    },
  })
</script>

<template>
  <button
    :disabled="isDisabled"
    class="bg-blue disabled:opacity-60 disabled:cursor-no-drop enabled:hover:bg-[#004EC3] text-white text-lg rounded-xl py-2.5 w-full transition mt-8"
    type="submit"
  >
    {{ title }}
  </button>
</template>
