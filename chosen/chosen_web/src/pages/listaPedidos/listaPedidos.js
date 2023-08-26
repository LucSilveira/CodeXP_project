import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import Menu from '../../components/menu/menu'
import Rodape from '../../components/rodape/rodape'
import './listaPedidos.css'

class ListaPedidos extends Component{
    render(){
        return(
            <>
                <Menu/>
                <Rodape/>
            </>
        )
    }
}

export default ListaPedidos