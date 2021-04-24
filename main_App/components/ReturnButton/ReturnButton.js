import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import Page from '../../constants/Page';

export default function ReturnButton ({onNavigateToPage}){
    return (
        <Link to ='/'><button onClick= {()=>onNavigateToPage(Page.mainMenu)} >Назад</button> </Link>
    )
}

ReturnButton.propTypes={
    onNavigateToPage: PropTypes.func.isRequired,
};