import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom';
import Page from "../../constants/Page";
import Status from '../../constants/Status';
import Loader from "../../containers/Loader";
import LearningArea from "../../containers/LearningArea";
import './style.css';

export default function ArticlePage (){
    return (
        <div><LearningArea pageIndication={false} /></div>
    )
}

ArticlePage.propTypes={
};