import React from "react";
import PropTypes from "prop-types";
import "./style.css";
import Page from "../../constants/Page";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

export default function NotFound({ onNavigateToPage }) {
    return (
        <div className='main-error'><div className='error-name'>Ошибка 404</div></div>
    )
}