import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import Menu from '../../components/menu/menu'
import Rodape from '../../components/rodape/rodape'
import './painelControle.css'

class PainelControle extends Component{
    render(){
        return(
            <>
                <Menu/>
                <Rodape/>
            </>
        )
    }
}

export default PainelControle