<template>
  <form @submit.prevent="submit">
    <input v-model="title" placeholder="Add new to-do…" required />
    <button type="submit">Add</button>
  </form>
</template>

<script>
export default {
  name: 'TodoForm',
  emits: ['add'],
  data: () => ({ title: '' }),
  methods: {
    submit() {
      this.$emit('add', { title: this.title, isCompleted: false });
      this.title = '';
    }
  }
};
</script>