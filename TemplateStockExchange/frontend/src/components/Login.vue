<template>
  <v-container
        class="fill-height"
        fluid
      >
        <v-row
          align="center"
          justify="center"
        >
          <v-col
            cols="12"
            sm="8"
            md="4"
          >
            <v-card class="elevation-12">
              <v-toolbar
                color="primary"
                dark
                flat
              >
                <v-toolbar-title>Login form</v-toolbar-title>
                <v-spacer></v-spacer>
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field
                    label="email"
                    name="login"
                    prepend-icon="person"
                    type="text"
                    v-model="email"
                  ></v-text-field>

                  <v-text-field
                    id="password"
                    label="Password"
                    name="password"
                    prepend-icon="lock"
                    type="password"
                    v-model="password"
                  ></v-text-field>
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="primary" @click="login">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
</template>

<script>
import axios from 'axios';
import { authenticationService } from '../variables'

export default {
  data(){
      return {
          email: '',
          password: ''
      }

  },
  methods: {
      login ()
      {
          console.log(this.email)
          console.log(this.password)
          axios.post(authenticationService, 
          {
              Email: this.email,
              Password: this.password
          })
          .then((response) => {
              var object = response.data
              localStorage.setItem('userObject', JSON.stringify(object));
              this.$router.push('/Mainpage')
          })
          .catch((error) => {
              alert(error)
          })
      }
  }
};


</script>



<style scoped>
</style>
