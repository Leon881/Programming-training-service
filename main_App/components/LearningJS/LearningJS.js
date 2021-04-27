import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import './style.css';
import AccordionMenu from "../../containers/AccordionMenu";
import Page from "../../constants/Page";

export default function LearningJS (){
    return (
      <AccordionMenu/>
    )
}

LearningJS.propTypes={
};