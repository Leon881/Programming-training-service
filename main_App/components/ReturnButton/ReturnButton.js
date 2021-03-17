import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import Page from '../../constants/Page';

export default function ReturnButton ({onNavigate}){
    return (
        <Link to ='/'><button onClick= {()=>onNavigate(Page.main)} >Назад</button> </Link>
    )
}

ReturnButton.propTypes={
    onNavigate: PropTypes.func.isRequired,
};