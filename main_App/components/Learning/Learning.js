import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom';
import Page from "../../constants/Page";
import AccordionMenu from "../../containers/AccordionMenu";
import './style.css';

export default function Learning (){
    return (
      <AccordionMenu/>
    )
}

Learning.propTypes={
  
};