import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import './home.css'
import Menu from '../../components/menu/menu'
import Rodape from '../../components/rodape/rodape'

class Home extends Component{
    render(){
        return(
            <>
                <Menu/>
                <Rodape/>
            </>
        )
    }
}

export default Home