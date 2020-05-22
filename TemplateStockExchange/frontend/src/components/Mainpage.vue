<template>
    <v-container>
        <v-container text-center>
            <h1> Hello {{ this.user.name }}!</h1>
        </v-container>
        <v-container>
            <v-row no-gutters class="match">
                <v-col>
                    <v-card
                    class="pa-2 text-center"
                    outlined
                    tile
                    
                    >
                    <h2>Available Stocks</h2>


                    <v-container>                        
                        <v-container v-for="item in stocks" :key="item.id">
                            <v-row >
                                <h2>{{ item.id}}</h2>
                                <h2>{{ item.name }}</h2>
                                <h2>{{ item.fullPrice}}</h2>
                                <v-btn>Buy</v-btn>
                            </v-row>
                        </v-container>
                    </v-container>

                    </v-card>
                </v-col>
                <v-col order="1">
                    <v-card
                    class="pa-2 text-center"
                    outlined
                    tile
                    >
                    <h2>My Stocks</h2>

                    </v-card>
                </v-col>
            </v-row>

        </v-container>
    </v-container>
</template>

<script>
import axios from 'axios';
import { availablestockService } from '../variables'

export default {

    

  data() {
      return{
          user: {},
          stocks: {}
      }
  },

  methods: {
      getStocks()
      {
        axios.get(availablestockService).then((response) => {
            this.stocks = response.data
            console.log(response.data)
        })
      }
  },
  created() {
      this.user = JSON.parse(localStorage.getItem('userObject'));
      this.getStocks();
  }
};
</script>

<style scoped>

h2{
    padding-left: 2rem;
}

</style>