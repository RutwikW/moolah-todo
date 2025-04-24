<template>
  <div class="provider-selector">
    <button
      :class="{ active: provider === '' }"
      @click="select('')"
    >DB</button>
    <button
      :class="{ active: provider === 'memory' }"
      @click="select('memory')"
    >Memory</button>
  </div>
</template>

<script>
export default {
  name: 'ProviderSelector',
  props: ['modelValue'],
  emits: ['change'],
  data: () => ({ provider: '' }),
  mounted() { this.provider = this.modelValue || '' },
  methods: {
    select(val) {
      this.provider = val;
      this.$emit('change', val);
    }
  }
}
</script>

<style scoped>
.provider-selector {
  display: inline-flex;
  border: 1px solid #ccc;
  border-radius: 6px;
  overflow: hidden;
}
.provider-selector button {
  flex: 1;
  padding: 0.5rem 1rem;
  border: none;
  background: #f5f5f5;
  cursor: pointer;
  font-weight: 500;
}
.provider-selector button.active {
  background: #42b983;
  color: white;
}
.provider-selector button:not(:last-child) {
  border-right: 1px solid #ccc;
}
</style>