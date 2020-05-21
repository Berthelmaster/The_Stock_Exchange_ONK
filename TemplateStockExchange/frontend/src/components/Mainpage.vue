<template>
    <v-container>
        <h1>ok</h1>
    </v-container>
</template>

<script>
export default {

  methods: {
  },
  created() {
      var retrievedObject = localStorage.getItem('userObject');
      alert(retrievedObject)
  }
};
</script>

<style scoped>

</style>