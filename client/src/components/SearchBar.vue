<template>
  <input
    v-model="query"
    type="text"
    placeholder="Search to-dos…"
    @input="onInput"
  />
</template>

<script>
import debounce from 'lodash.debounce';

export default {
  name: 'SearchBar',
  emits: ['search'],
  data: () => ({ query: '' }),
  methods: {
    onInput: debounce(function () {
      this.$emit('search', this.query);
    }, 300)
  }
};
</script>