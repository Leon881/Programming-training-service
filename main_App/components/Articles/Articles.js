import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import ReturnButton from "../../containers/ReturnButton";

export default function Articles () {
    return (
        <div>
        <ReturnButton/>
      <p>Статьи</p>
      </div>
    )
}

Articles.propTypes = {
}
